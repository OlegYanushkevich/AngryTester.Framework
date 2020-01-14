namespace AngryTester.Framework.Abstract.Observing
{
    using System.Reflection;

    /// <summary>
    /// Represent Test execution status.
    /// </summary>
    /// <typeparam name="TContext">Test context.</typeparam>
    public class ExecutionStatus<TContext>
        where TContext : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionStatus{TContext}"/> class.
        /// </summary>
        /// <param name="testContext">Test Context.</param>
        /// <param name="executionPhase">Execution Phase <see cref="ExecutionPhase"/>.</param>
        public ExecutionStatus(TContext testContext, ExecutionPhase executionPhase)
            : this(testContext, null, executionPhase)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionStatus{TContext}"/> class.
        /// </summary>
        /// <param name="testContext">Test Context.</param>
        /// <param name="memberInfo"><see cref="MemberInfo">Info</see> about current executed test method.</param>
        /// <param name="executionPhase">Execution Phase <see cref="ExecutionPhase"/>.</param>
        public ExecutionStatus(TContext testContext, MemberInfo memberInfo, ExecutionPhase executionPhase)
        {
            TestContext = testContext;
            MemberInfo = memberInfo;
            Phase = executionPhase;
        }

        /// <summary>
        /// Gets or sets current test context.
        /// </summary>
        public TContext TestContext { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MemberInfo">method info about current executing test</see>.
        /// </summary>
        public MemberInfo MemberInfo { get; protected set; }

        /// <summary>
        /// Gets or sets <see cref="ExecutionPhase">execution phase</see>.
        /// </summary>
        public ExecutionPhase Phase { get; protected set; }
    }
}
