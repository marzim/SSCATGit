// <copyright file="Kernel32.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Process information
    /// </summary>
    public enum PROCESSINFOCLASS : int
    {
        /// <summary>
        /// Retrieves a pointer to a PEB structure that can be used to determine whether the specified process is being debugged, and a unique value used by the system to identify the specified process.
        /// </summary>
        ProcessBasicInformation = 0,

        /// <summary>
        /// Process quota limits
        /// </summary>
        ProcessQuotaLimits,

        /// <summary>
        /// Process IO counters
        /// </summary>
        ProcessIoCounters,

        /// <summary>
        /// Process VM counters
        /// </summary>
        ProcessVmCounters,

        /// <summary>
        /// Process times
        /// </summary>
        ProcessTimes,

        /// <summary>
        /// Gets the base priority of the associated process.
        /// </summary>
        ProcessBasePriority,

        /// <summary>
        /// Process raise priority
        /// </summary>
        ProcessRaisePriority,

        /// <summary>
        /// Process debug port
        /// </summary>
        ProcessDebugPort,

        /// <summary>
        /// Process exception port
        /// </summary>
        ProcessExceptionPort,

        /// <summary>
        /// Process access token
        /// </summary>
        ProcessAccessToken,

        /// <summary>
        /// Process LDT information
        /// </summary>
        ProcessLdtInformation,

        /// <summary>
        /// Process LDT size
        /// </summary>
        ProcessLdtSize,

        /// <summary>
        /// Process default hard error mode
        /// </summary>
        ProcessDefaultHardErrorMode,

        /// <summary>
        /// Process IO Port handlers
        /// </summary>
        ProcessIoPortHandlers, // Note: this is kernel mode only

        /// <summary>
        /// Process pooled usage and limits
        /// </summary>
        ProcessPooledUsageAndLimits,

        /// <summary>
        /// Process working set watch
        /// </summary>
        ProcessWorkingSetWatch,

        /// <summary>
        /// Process user mode IOPL
        /// </summary>
        ProcessUserModeIOPL,

        /// <summary>
        /// Process enable alignment fault fix up
        /// </summary>
        ProcessEnableAlignmentFaultFixup,

        /// <summary>
        /// Process priority class
        /// </summary>
        ProcessPriorityClass,

        /// <summary>
        /// Process WX86 Information
        /// </summary>
        ProcessWx86Information,

        /// <summary>
        /// Process handle count
        /// </summary>
        ProcessHandleCount,

        /// <summary>
        /// Process affinity mask
        /// </summary>
        ProcessAffinityMask,

        /// <summary>
        /// Process priority boost
        /// </summary>
        ProcessPriorityBoost,

        /// <summary>
        /// Max process information class
        /// </summary>
        MaxProcessInfoClass
    }

    /// <summary>
    /// Desired access
    /// </summary>
    public enum EDesiredAccess : int
    {
        /// <summary>
        /// The right to delete the object.
        /// </summary>
        DELETE = 0x00010000,

        /// <summary>
        /// The right to read the information in the object's security descriptor, not including the information in the system access control list (SACL).
        /// </summary>
        READ_CONTROL = 0x00020000,

        /// <summary>
        /// The right to modify the discretionary access control list (DACL) in the object's security descriptor.
        /// </summary>
        WRITE_DAC = 0x00040000,

        /// <summary>
        /// The right to change the owner in the object's security descriptor.
        /// </summary>
        WRITE_OWNER = 0x00080000,

        /// <summary>
        /// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state. Some object types do not support this access right.
        /// </summary>
        SYNCHRONIZE = 0x00100000,

        /// <summary>
        /// Combines DELETE, READ_CONTROL, WRITE_DAC, WRITE_OWNER, and SYNCHRONIZE access.
        /// </summary>
        STANDARD_RIGHTS_ALL = 0x001F0000,

        /// <summary>
        /// Required to terminate a process using TerminateProcess.
        /// </summary>
        PROCESS_TERMINATE = 0x0001,

        /// <summary>
        /// Required to create a thread.
        /// </summary>
        PROCESS_CREATE_THREAD = 0x0002,

        /// <summary>
        /// Process set session ID
        /// </summary>
        PROCESS_SET_SESSIONID = 0x0004,

        /// <summary>
        /// Required to perform an operation on the address space of a process
        /// </summary>
        PROCESS_VM_OPERATION = 0x0008,

        /// <summary>
        /// Required to read memory in a process using ReadProcessMemory.
        /// </summary>
        PROCESS_VM_READ = 0x0010,

        /// <summary>
        /// Required to write to memory in a process using WriteProcessMemory.
        /// </summary>
        PROCESS_VM_WRITE = 0x0020,

        /// <summary>
        /// Required to duplicate a handle using DuplicateHandle.
        /// </summary>
        PROCESS_DUP_HANDLE = 0x0040,

        /// <summary>
        /// Required to create a process.
        /// </summary>
        PROCESS_CREATE_PROCESS = 0x0080,

        /// <summary>
        /// Required to set memory limits using SetProcessWorkingSetSize.
        /// </summary>
        PROCESS_SET_QUOTA = 0x0100,

        /// <summary>
        /// Required to set certain information about a process, such as its priority class
        /// </summary>
        PROCESS_SET_INFORMATION = 0x0200,

        /// <summary>
        /// Required to retrieve certain information about a process, such as its token, exit code, and priority class
        /// </summary>
        PROCESS_QUERY_INFORMATION = 0x0400,

        /// <summary>
        /// All possible access rights for a process object.
        /// </summary>
        PROCESS_ALL_ACCESS = SYNCHRONIZE | 0xFFF
    }
    
    /// <summary>
    /// Initializes a new instance of the Kernel32 class
    /// </summary>
    public class Kernel32
    {
        /// <summary>
        /// Initializes a new instance of the Kernel32 class
        /// </summary>
        public Kernel32()
        {
        }

        /// <summary>
        /// Sets the current system time and date. The system time is expressed in Coordinated Universal Time (UTC).
        /// </summary>
        /// <param name="time">A pointer to a SYSTEMTIME structure that contains the new system date and time.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime([In] ref SYSTEMTIME time);

        /// <summary>
        /// Opens an existing local process object.
        /// </summary>
        /// <param name="dwDesiredAccess">The access to the process object. This access right is checked against the security descriptor for the process. This parameter can be one or more of the process access rights.</param>
        /// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwProcessId">The identifier of the local process to be opened.</param>
        /// <returns>If the function succeeds, the return value is an open handle to the specified process.</returns>
        [DllImport("KERNEL32.DLL")]
        public static extern int OpenProcess(EDesiredAccess dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("KERNEL32.DLL")]
        public static extern int CloseHandle(int hObject);

        /// <summary>
        /// Retrieves information about the specified process.
        /// </summary>
        /// <param name="hProcess">A handle to the process for which information is to be retrieved.</param>
        /// <param name="pic">The type of process information to be retrieved. This parameter can be one of the following values from the PROCESSINFOCLASS enumeration.</param>
        /// <param name="pbi">When the ProcessInformationClass parameter is ProcessBasicInformation, the buffer pointed to by the ProcessInformation parameter should be large enough to hold a single PROCESS_BASIC_INFORMATION structure.</param>
        /// <param name="cb">The size of the buffer pointed to by the ProcessInformation parameter, in bytes.</param>
        /// <param name="pSize">A pointer to a variable in which the function returns the size of the requested information.</param>
        /// <returns>The function returns an NTSTATUS success or error code.</returns>
        [DllImport("NTDLL.DLL")]
        public static extern int NtQueryInformationProcess(int hProcess, PROCESSINFOCLASS pic, ref PROCESS_BASIC_INFORMATION pbi, int cb, ref int pSize);
    }
}
