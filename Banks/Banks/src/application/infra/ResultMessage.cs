namespace Banks.application.infra
{
    public class ResultMessage<T> : ErrorMessage
    {
        private T result;

        public ResultMessage()
        {
            
        }

        public void SetResult(T result)
        {
            this.result = result;
        }

        public T GetResult()
        {
            return result;
        }
        
        

    }
}