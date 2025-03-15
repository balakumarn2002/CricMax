using System.Collections.Generic;

namespace Aveon.CMS.Model
{
    public class ApiResult<T>
    {
        public ApiResult()
        {
            ErrorMessages = new List<string>();

            WarningMessages = new List<string>();
        }

        public ICollection<string> ErrorMessages { get; private set; }

        public ICollection<string> WarningMessages { get; private set; }

        public bool IsSuccess
        {
            get
            {
                return ErrorMessages.Count == 0 && WarningMessages.Count == 0;
            }
        }

        public bool HasWarnings { get { return WarningMessages.Count > 0; } }

        public T Result { get; set; }

        public void AddErrorMessage(string format, params object[] args)
        {
            AddErrorMessage(string.Format(format, args));
        }

        public void AddErrorMessage(string message)
        {
            if (!ErrorMessages.Contains(message))
            {
                ErrorMessages.Add(message);
            }
        }

        public void CloneMessages<R>(ApiResult<R> source, bool treatErrorsAsWarnings = false)
        {
            foreach (var item in source.ErrorMessages)
            {
                if (treatErrorsAsWarnings)
                {
                    AddWarningMessage(item);
                }
                else
                {
                    AddErrorMessage(item);
                }
            }

            foreach (var warningitem in source.WarningMessages)
            {
                WarningMessages.Add(warningitem);
            }
        }

        public void AddWarningMessage(string format, params object[] args)
        {
            WarningMessages.Add(string.Format(format, args));
        }

        public void AddWarningMessage(string message)
        {
            WarningMessages.Add(message);
        }
        public decimal? ResultNumber { get; set; }
    }
}