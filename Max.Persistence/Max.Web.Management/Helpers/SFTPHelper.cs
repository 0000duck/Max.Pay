
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;
using Max.Framework;

namespace Max.Web.Management
{
    public class SFTPHelper
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SFTPHelper));
        private SessionOptions sessionOptions;

        public SFTPHelper(SFTPConfig config)
        {
            this.sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = config.HostName,
                UserName = config.UserName,
                Password = config.Password,
                GiveUpSecurityAndAcceptAnySshHostKey = true,
                PortNumber = config.PortNumber,
            };
        }
        private SFTPHelper()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        /// <param name="mode">默认同步到本地</param>
        /// <returns></returns>
        public SynchronizationResult SynchronizeDirectories(string remotePath, string localPath, SynchronizationMode mode = SynchronizationMode.Local)
        {
            try
            {
                using (Session session = new Session())
                {
                    session.ExecutablePath = AppDomain.CurrentDomain.BaseDirectory + "/Files/WinSCP.exe";
                    session.Open(sessionOptions);
                    if (mode == SynchronizationMode.Local)
                    {
                        if (!session.FileExists(remotePath))
                            return null;
                        if (!Directory.Exists(localPath))
                            Directory.CreateDirectory(localPath);
                    }
                    else if (mode == SynchronizationMode.Remote && !session.FileExists(remotePath))
                    {
                        session.CreateDirectory(remotePath);
                    }
                    var res = session.SynchronizeDirectories(mode, localPath, remotePath, true, false, SynchronizationCriteria.Either);
                    res.Check();
                    return res;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return null;
            }
        }

        public TransferOperationResult Upload(string localPath, string remotePath)
        {
            try
            {
                using (Session session = new Session())
                {
                    session.ExecutablePath = AppDomain.CurrentDomain.BaseDirectory + "/Files/WinSCP.exe";
                    session.Open(sessionOptions);
                    var transferOptions = new TransferOptions();
                    transferOptions.ResumeSupport = new TransferResumeSupport { State = TransferResumeSupportState.Off };
                    var res = session.PutFiles(localPath, remotePath, false, transferOptions);
                    res.Check();
                    return res;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="remotePath">远程目录或者文件</param>
        /// <param name="localPath">本地目录或者文件</param>
        /// <returns></returns>
        public TransferOperationResult Download(string remotePath, string localPath)
        {
            try
            {
                using (Session session = new Session())
                {
                    session.ExecutablePath = AppDomain.CurrentDomain.BaseDirectory + "/Files/WinSCP.exe";
                    session.Open(sessionOptions);
                    var transferOptions = new TransferOptions();
                    transferOptions.ResumeSupport = new TransferResumeSupport { State = TransferResumeSupportState.Off };
                    var res = session.GetFiles(remotePath, localPath, false, transferOptions);
                    res.Check();

                    return res;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="remotePath">远程目录或者文件集合</param>
        /// <param name="localPath">本地目录或者文件</param>
        /// <returns></returns>
        public TransferOperationResult Download(List<string> remotePath, string localPath)
        {
            try
            {
                using (Session session = new Session())
                {
                    session.ExecutablePath = AppDomain.CurrentDomain.BaseDirectory + "/Files/WinSCP.exe";
                    session.Open(sessionOptions);
                    var transferOptions = new TransferOptions();
                    transferOptions.ResumeSupport = new TransferResumeSupport { State = TransferResumeSupportState.Off };
                    int count = 0;
                    TransferOperationResult res = null;
                    foreach (var item in remotePath)
                    {
                        if (!item.IsNullOrWhiteSpace())
                        {
                            res = session.GetFiles("/" + item, localPath, false, transferOptions);
                            res.Check();
                            if (!res.IsSuccess)
                            {
                                logger.Error(res.Failures[0].Message);
                                break;
                            }
                            count++;
                        }

                    }


                    return res;

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return null;
            }
        }

        public void CreateDirectory(string path)
        {
            try
            {
                using (Session session = new Session())
                {
                    session.ExecutablePath = AppDomain.CurrentDomain.BaseDirectory + "/Files/WinSCP.exe";
                    session.Open(sessionOptions);
                    if (session.FileExists(path))
                    {
                        return;
                    }

                    session.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
