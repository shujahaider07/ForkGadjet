using System.ComponentModel.DataAnnotations;

namespace EntitiesViewModels
{
    public class Response
    {

        public Int64 returnId { get; set; }
        public string returnStatus { get; set; }
        public string returnText { get; set; }
        public string returnCode { get; set; }
        public object returnObject { get; set; }
        public string returnException { get; set; }


    }

    public class ResponseODATA<T>
    {
        [Key]
        public Int64 returnId { get; set; }
        public string returnStatus { get; set; }
        public string returnText { get; set; }
        public string returnCode { get; set; }
        public List<T> returnObject { get; set; }
        public string returnException { get; set; }
    }

    public class JsonResponseFromSQL
    {
        public String JsonData { get; set; }
    }
}
