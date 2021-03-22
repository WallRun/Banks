using System.Collections.Generic;

namespace Banks.application.infra
{
    public class ErrorMessage
    {
        private string title;
        private readonly List<string> errorList = new();


        public void AddError(string error)
        {
            errorList.Add(error);
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public bool HasError()
        {
            return errorList.Count != 0;
        }
    }
}