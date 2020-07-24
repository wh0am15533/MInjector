using MInject;
using System;
using System.Diagnostics;

namespace MInjector
{
    public static class MonoInjector
    {
        public static bool Inject(Process p_TargetProcess, Settings p_InjectionSettings)
        {
            MonoProcess monoProcess;

            //Try to attach to targetProcess Mono module
            if (MonoProcess.Attach(p_TargetProcess, out monoProcess))
            {
                try
                {
                    IntPtr monoDomain = monoProcess.GetRootDomain();
                    monoProcess.ThreadAttach(monoDomain);
                    monoProcess.SecuritySetMode(0);

                    //Disable AssemblyLoad callbacks before injection
                    if (p_InjectionSettings.HideAssemblyLoad)
                    {
                        monoProcess.DisableAssemblyLoadCallback();
                    }

                    IntPtr rawAssemblyImage = monoProcess.ImageOpenFromDataFull(p_InjectionSettings.AssemblyBytes);
                    IntPtr assemblyPointer = monoProcess.AssemblyLoadFromFull(rawAssemblyImage);
                    IntPtr assemblyImage = monoProcess.AssemblyGetImage(assemblyPointer);
                    IntPtr classPointer = monoProcess.ClassFromName(assemblyImage, p_InjectionSettings.Namespace, p_InjectionSettings.ClassName);
                    IntPtr methodPointer = monoProcess.ClassGetMethodFromName(classPointer, p_InjectionSettings.MethodName);

                    //Finally invoke the TestInjection.Loader.Init method
                    monoProcess.RuntimeInvoke(methodPointer);

                    //Restore the AssemblyLoad callbacks to avoid weird behaviours
                    if (p_InjectionSettings.HideAssemblyLoad)
                    {
                        monoProcess.EnableAssemblyLoadCallback();
                    }

                    //You MUST dispose the MonoProcess instance when finished
                    monoProcess.Dispose();
                    return true;
                }
                catch { }
            }

            return false;
        }

        public class Settings
        {
            public byte[] AssemblyBytes { get; set; }

            public string Namespace { get; set; }

            public string ClassName { get; set; }

            public string MethodName { get; set; }

            public bool HideAssemblyLoad { get; set; }
        }
    }
}
