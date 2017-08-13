using System.Collections.Generic;

namespace BPMNET.Core
{
    public class BpmResult
    {
        private static readonly BpmResult success = new BpmResult(true);
        /// <summary>
        ///     True if the operation was successful
        /// </summary>
        public bool Succeeded
        {
            get;
            private set;
        }
        /// <summary>
        ///     List of errors
        /// </summary>
        public IEnumerable<string> Errors
        {
            get;
            private set;
        }
        /// <summary>
        ///     Static success processInstance
        /// </summary>
        /// <returns></returns>
        public static BpmResult Success
        {
            get
            {
                return success;
            }
        }
        /// <summary>
        ///     Failure constructor that takes error messages
        /// </summary>
        /// <param name="errors"></param>
        public BpmResult(params string[] errors)
            : this((IEnumerable<string>)errors)
        {
        }
        /// <summary>
        ///     Failure constructor that takes error messages
        /// </summary>
        /// <param name="errors"></param>
        public BpmResult(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                errors = new string[]
                {
                    "An unknown failure has occured"
                };
            }
            Succeeded = false;
            Errors = errors;
        }
        /// <summary>
        /// Constructor that takes whether the processInstance is successful
        /// </summary>
        /// <param name="success"></param>
        protected BpmResult(bool success)
        {
            Succeeded = success;
            Errors = new string[0];
        }
        /// <summary>
        ///     Failed helper method
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static BpmResult Failed(params string[] errors)
        {
            return new BpmResult(errors);
        }
    }
}
