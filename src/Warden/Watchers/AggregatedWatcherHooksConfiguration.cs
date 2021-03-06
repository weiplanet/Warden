﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Warden.Watchers
{
    /// <summary>
    /// Configuration of the hooks for the aggregated watchers.
    /// </summary>
    public class AggregatedWatcherHooksConfiguration
    {
        private readonly ISet<Expression<Action<IEnumerable<IWardenCheckResult>>>> _onSuccess = new HashSet<Expression<Action<IEnumerable<IWardenCheckResult>>>>();
        private readonly ISet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> _onSuccessAsync = new HashSet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>>();
        private readonly ISet<Expression<Action<IEnumerable<IWardenCheckResult>>>> _onFirstSuccess = new HashSet<Expression<Action<IEnumerable<IWardenCheckResult>>>>();
        private readonly ISet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> _onFirstSuccessAsync = new HashSet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>>();
        private readonly ISet<Expression<Action<IEnumerable<IWardenCheckResult>>>> _onFailure = new HashSet<Expression<Action<IEnumerable<IWardenCheckResult>>>>();
        private readonly ISet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> _onFailureAsync = new HashSet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>>();
        private readonly ISet<Expression<Action<IEnumerable<IWardenCheckResult>>>> _onFirstFailure = new HashSet<Expression<Action<IEnumerable<IWardenCheckResult>>>>();
        private readonly ISet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> _onFirstFailureAsync = new HashSet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>>();
        private readonly ISet<Expression<Action<IEnumerable<IWardenCheckResult>>>> _onCompleted = new HashSet<Expression<Action<IEnumerable<IWardenCheckResult>>>>();
        private readonly ISet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> _onCompletedAsync = new HashSet<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>>();
        private readonly ISet<Expression<Action<IEnumerable<Exception>>>> _onError = new HashSet<Expression<Action<IEnumerable<Exception>>>>();
        private readonly ISet<Expression<Func<IEnumerable<Exception>, Task>>> _onErrorAsync = new HashSet<Expression<Func<IEnumerable<Exception>, Task>>>();
        private readonly ISet<Expression<Action<IEnumerable<Exception>>>> _onFirstError = new HashSet<Expression<Action<IEnumerable<Exception>>>>();
        private readonly ISet<Expression<Func<IEnumerable<Exception>, Task>>> _onFirstErrorAsync = new HashSet<Expression<Func<IEnumerable<Exception>, Task>>>();

        /// <summary>
        /// Set of unique OnSuccess hooks for the aggregated watchers, invoked when the ExecuteAsync() succeeded.
        /// </summary>
        public IEnumerable<Expression<Action<IEnumerable<IWardenCheckResult>>>> OnSuccess => _onSuccess;

        /// <summary>
        /// Set of unique OnSuccessAsync hooks for the aggregated watchers, invoked when the ExecuteAsync() succeeded.
        /// </summary>
        public IEnumerable<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> OnSuccessAsync => _onSuccessAsync;

        /// <summary>
        /// Set of unique OnFirstSuccess hooks for the aggregated watchers, 
        /// invoked when the ExecuteAsync() succeeded for the first time after the previous check didn't succeed.
        /// </summary>
        public IEnumerable<Expression<Action<IEnumerable<IWardenCheckResult>>>> OnFirstSuccess => _onFirstSuccess;

        /// <summary>
        /// Set of unique OnFirstSuccessAsync hooks for the aggregated watchers, 
        /// invoked when the ExecuteAsync() succeeded for the first time after the previous check didn't succeed.
        /// </summary>
        public IEnumerable<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> OnFirstSuccessAsync => _onFirstSuccessAsync;

        /// <summary>
        /// Set of unique OnFailure hooks for the aggregated watchers, invoked when the ExecuteAsync() is failed.
        /// </summary>
        public IEnumerable<Expression<Action<IEnumerable<IWardenCheckResult>>>> OnFailure => _onFailure;

        /// <summary>
        /// Set of unique OnFailureAsync hooks for the aggregated watchers, invoked when the ExecuteAsync() is failed.
        /// </summary>
        public IEnumerable<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> OnFailureAsync => _onFailureAsync;

        /// <summary>
        /// Set of unique OnFirstFailure hooks for the aggregated watchers, 
        /// invoked when the ExecuteAsync() failed for the first time after the previous check did succeed.
        /// </summary>
        public IEnumerable<Expression<Action<IEnumerable<IWardenCheckResult>>>> OnFirstFailure => _onFirstFailure;

        /// <summary>
        /// Set of unique OnFirstFailureAsync hooks for the aggregated watchers, 
        /// invoked when the ExecuteAsync() failed for the first time after the previous check did succeed.
        /// </summary>
        public IEnumerable<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> OnFirstFailureAsync => _onFirstFailureAsync;

        /// <summary>
        /// Set of unique OnCompleted hooks for the aggregated watchers,
        /// invoked when the ExecuteAsync() completed, regardless it's succeeded or not.
        /// </summary>
        public IEnumerable<Expression<Action<IEnumerable<IWardenCheckResult>>>> OnCompleted => _onCompleted;

        /// <summary>
        /// Set of unique OnCompletedAsync hooks for the aggregated watchers, 
        /// invoked when the ExecuteAsync() completed, regardless it's succeeded or not.
        /// </summary>
        public IEnumerable<Expression<Func<IEnumerable<IWardenCheckResult>, Task>>> OnCompletedAsync => _onCompletedAsync;

        /// <summary>
        /// Set of unique OnError hooks for the aggregated watchers, invoked when the ExecuteAsync() threw an exception.
        /// </summary>
        public IEnumerable<Expression<Action<IEnumerable<Exception>>>> OnError => _onError;

        /// <summary>
        /// Set of unique OnErrorAsync hooks for the aggregated watchers, invoked when the ExecuteAsync() threw an exception.
        /// </summary>
        public IEnumerable<Expression<Func<IEnumerable<Exception>, Task>>> OnErrorAsync => _onErrorAsync;

        /// <summary>
        /// Set of unique OnFirstError hooks for the aggregated watchers, invoked when the ExecuteAsync()
        /// threw an exception for the first time after the previous check either succeeded or not.
        /// </summary>
        public IEnumerable<Expression<Action<IEnumerable<Exception>>>> OnFirstError => _onFirstError;

        /// <summary>
        /// Set of unique OnFirstErrorAsync hooks for the aggregated watchers, invoked when the ExecuteAsync()
        /// threw an exception for the first time after the previous check either succeeded or not.
        /// </summary>
        public IEnumerable<Expression<Func<IEnumerable<Exception>, Task>>> OnFirstErrorAsync => _onFirstErrorAsync;

        protected internal AggregatedWatcherHooksConfiguration()
        {
        }

        /// <summary>
        /// An empty, default configuration of the watcher hooks, that has no hooks defined.
        /// </summary>
        public static AggregatedWatcherHooksConfiguration Empty => new AggregatedWatcherHooksConfiguration();

        /// <summary>
        /// Factory method for creating a new instance of fluent builder for the AggregatedWatcherHooksConfiguration.
        /// </summary>
        /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
        public static Builder Create() => new Builder();

        public class Builder
        {
            private readonly AggregatedWatcherHooksConfiguration _configuration = new AggregatedWatcherHooksConfiguration();

            protected internal Builder()
            {
            }

            /// <summary>
            /// One or more unique OnSuccess hooks for the aggregated watchers, invoked when the ExecuteAsync() succeeded.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnSuccess(params Expression<Action<IEnumerable<IWardenCheckResult>>>[] hooks)
            {
                _configuration._onSuccess.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnSuccessAsync hooks for the aggregated watchers, invoked when the ExecuteAsync() succeeded.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnSuccessAsync(params Expression<Func<IEnumerable<IWardenCheckResult>, Task>>[] hooks)
            {
                _configuration._onSuccessAsync.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnFirstSuccess hooks for the aggregated watchers, 
            /// invoked when the ExecuteAsync() succeeded for the first time after the previous check didn't succeed.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFirstSuccess(params Expression<Action<IEnumerable<IWardenCheckResult>>>[] hooks)
            {
                _configuration._onFirstSuccess.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnFirstSuccessAsync hooks for the aggregated watchers, 
            /// invoked when the ExecuteAsync() succeeded for the first time after the previous check didn't succeed.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFirstSuccessAsync(params Expression<Func<IEnumerable<IWardenCheckResult>, Task>>[] hooks)
            {
                _configuration._onFirstSuccessAsync.UnionWith(hooks);
                return this;
            }
            /// <summary>
            /// One or more unique OnFailure hooks for the aggregated watchers, invoked when the ExecuteAsync() is failed.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFailure(params Expression<Action<IEnumerable<IWardenCheckResult>>>[] hooks)
            {
                _configuration._onFailure.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnFailureAsync hooks for the aggregated watchers, invoked when the ExecuteAsync() is failed.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFailureAsync(params Expression<Func<IEnumerable<IWardenCheckResult>, Task>>[] hooks)
            {
                _configuration._onFailureAsync.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnFirstFailure hooks for the aggregated watchers, 
            /// invoked when the ExecuteAsync() failed for the first time after the previous check did succeed.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFirstFailure(params Expression<Action<IEnumerable<IWardenCheckResult>>>[] hooks)
            {
                _configuration._onFirstFailure.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnFirstFailureAsync hooks for the aggregated watchers, 
            /// invoked when the ExecuteAsync() failed for the first time after the previous check did succeed.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFirstFailureAsync(params Expression<Func<IEnumerable<IWardenCheckResult>, Task>>[] hooks)
            {
                _configuration._onFirstFailureAsync.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnCompleted hooks for the aggregated watchers,
            /// invoked when the ExecuteAsync() completed, regardless it's succeeded or not.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnCompleted(params Expression<Action<IEnumerable<IWardenCheckResult>>>[] hooks)
            {
                _configuration._onCompleted.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnCompletedAsync hooks for the aggregated watchers, 
            /// invoked when the ExecuteAsync() completed, regardless it's succeeded or not.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnCompletedAsync(params Expression<Func<IEnumerable<IWardenCheckResult>, Task>>[] hooks)
            {
                _configuration._onCompletedAsync.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnError hooks for the aggregated watchers, invoked when the ExecuteAsync() threw an exception.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnError(params Expression<Action<IEnumerable<Exception>>>[] hooks)
            {
                _configuration._onError.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnErrorAsync hooks for the aggregated watchers, invoked when the ExecuteAsync() threw an exception.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnErrorAsync(params Expression<Func<IEnumerable<Exception>, Task>>[] hooks)
            {
                _configuration._onErrorAsync.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnFirstError hooks for the aggregated watchers, invoked when the ExecuteAsync()
            /// threw an exception for the first time after the previous check either succeeded or not.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFirstError(params Expression<Action<IEnumerable<Exception>>>[] hooks)
            {
                _configuration._onFirstError.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// One or more unique OnFirstErrorAsync hooks for the aggregated watchers, invoked when the ExecuteAsync()
            /// threw an exception for the first time after the previous check either succeeded or not.
            /// </summary>
            /// <param name="hooks">One or more custom aggregated watchers hooks.</param>
            /// <returns>Instance of fluent builder for the AggregatedWatcherHooksConfiguration.</returns>
            public Builder OnFirstErrorAsync(params Expression<Func<IEnumerable<Exception>, Task>>[] hooks)
            {
                _configuration._onFirstErrorAsync.UnionWith(hooks);
                return this;
            }

            /// <summary>
            /// Builds the WatcherHooksConfiguration and return its instance.
            /// </summary>
            /// <returns>Instance of WatcherHooksConfiguration.</returns>
            public AggregatedWatcherHooksConfiguration Build() => _configuration;
        }
    }
}