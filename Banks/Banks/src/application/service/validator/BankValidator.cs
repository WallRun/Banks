using Banks.application.infra;
using Banks.model.bank;

namespace Banks.application.service.validator
{
    public class BankValidator
    {
        public static ErrorMessage Validate(Bank bank)
        {
            ErrorMessage errorMessage = new();
            
            if (bank == null)
            {
                errorMessage.AddError("Параметр не може дорівнювати null");
                return errorMessage;
            }

            string name = bank.GetName();

            if (name == null || name.Trim() == "")
            {
                errorMessage.AddError("Найменування банку є обов'язковим для заповнення");
            }

            return errorMessage;
        }
    }
}