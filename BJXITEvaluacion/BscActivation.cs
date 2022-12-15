using Bjxit.Evaluacion.Model.Diccionaries;
using Community.Core.EnterpriseLibrary.Activation;


namespace BJXITEvaluacion
{

    public class BscActivation: IDatDefActiv
    {
        #region Properties

        public string Kn => AppSettingInfo.KeyNumber;        
        public string Uk => "obZfA5DPpB4V5EoN9Rb5GQ==";

        public string Sk => AppSettingInfo.SaltKey;



        #endregion Properties



        #region Constructor



        public BscActivation()
        {
        }



        #endregion Constructor
    }
}
