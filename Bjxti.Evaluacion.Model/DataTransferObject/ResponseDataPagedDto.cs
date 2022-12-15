using Community.Core.EnterpriseLibrary.Model.Dto;


namespace Bjxit.Evaluacion.Model.DataTransferObject
{
    public class ResponseDataPagedDto<T> : ResponseDataDto<T>
    {
        public int FilteredRows { get; set;}
        public int TotalRows { get; set; }
    }
                       

}

