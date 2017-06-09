using Case.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Case.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMailer" in both code and config file together.
    [ServiceContract]
    public interface IMailer
    {
        [OperationContract]
        void CancelEmailProcess();
        [OperationContract]
        void StartEmailProcess(System.Collections.Generic.List<Messages> data);
    }
}
