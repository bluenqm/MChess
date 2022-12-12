using System;
using System.Runtime.InteropServices;
using System.IO;

namespace PlaySound
{
    /// <summary>
    /// Helper for playing wav files and System Events stored under HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default
    /// </summary>
    public class WPlaySound
    {
        [DllImport("WinMM.dll", EntryPoint = "PlaySound", CharSet = CharSet.Auto)]
        private static extern int PlaySoundWin32(string pszSound, int hmod, int fdwSound);

        [DllImport("CoreDll.dll", EntryPoint = "PlaySound", CharSet = CharSet.Auto)]
        private static extern int PlaySoundWinCE(string pszSound, int hmod, int fdwSound);

        private const int Win32 = 0;
        private const int WinCE = 1;
        private static int Windows = -1;

        /// <summary>
        ///
        /// </summary>
        public WPlaySound()
        {
        }
        /// <summary>
        /// API Parameter Flags for PlaySound method
        /// </summary>
        public enum SND
        {
            SND_SYNC = 0x0000,/* play synchronously (default) */
            SND_ASYNC = 0x0001, /* play asynchronously */
            SND_NODEFAULT = 0x0002, /* silence (!default) if sound not found */
            SND_MEMORY = 0x0004, /* pszSound points to a memory file */
            SND_LOOP = 0x0008, /* loop the sound until next sndPlaySound */
            SND_NOSTOP = 0x0010, /* don't stop any currently playing sound */
            SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
            SND_ALIAS = 0x00010000,/* name is a registry alias */
            SND_ALIAS_ID = 0x00110000, /* alias is a pre d ID */
            SND_FILENAME = 0x00020000, /* name is file name */
            SND_RESOURCE = 0x00040004, /* name is resource name or atom */
            SND_PURGE = 0x0040,  /* purge non-static events for task */
            SND_APPLICATION = 0x0080  /* look for application specific association */
        }

        /// <summary>
        /// Play System Event stored under HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default
        /// </summary>
        /// <param name="pszSound">SystemEvent Verb</param>
        public static void PlaySoundEvent(String pszSound)
        {
            switch (Windows)
            {
                case Win32:
                    PlaySoundWin32(pszSound, 0, (int)(SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT));
                    break;
                case WinCE:
                    PlaySoundWinCE(pszSound, 0, (int)(SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT));
                    break;
                default:
                    try
                    {
                        PlaySoundWin32(pszSound, 0, (int)(SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT));
                        Windows = Win32;
                    }
                    catch
                    {
                        PlaySoundWinCE(pszSound, 0, (int)(SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT));
                        Windows = WinCE;
                    }
                    break;
            }
        }
    }

}