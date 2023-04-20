namespace ChemistWarehouseTechTest.Results
{
    public class GenericEntityResult<T>
    {
        public bool IsSuccess { get; set; }
        
        public string Error { get; set; }
        
        public int StatusCode { get; set; }
        
        public T Data { get; set; }

        public static GenericEntityResult<T> Ok(T data)
        {
            return new GenericEntityResult<T>()
            {
                Data = data,
                IsSuccess = true,
                StatusCode = 200
            };
        }

        public static GenericEntityResult<T> BadRequest(string error)
        {
            return new GenericEntityResult<T>()
            {
                Error = error,
                IsSuccess = false,
                StatusCode = 400
            };
        }
    }
}