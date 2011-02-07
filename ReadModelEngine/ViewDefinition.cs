using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ManagedViewEngine
{    
    public abstract class ViewDefinition
    {
        private readonly List<LambdaExpression> _indexExpressions = new List<LambdaExpression>();
        private readonly List<LambdaExpression> _sharedExpressions = new List<LambdaExpression>();

        public IEnumerable<LambdaExpression> IndexExpressions
        {
            get { return _indexExpressions; }
        }

        public IEnumerable<LambdaExpression> SharedExpressions
        {
            get { return _sharedExpressions; }
        }

        protected void AddIndexExpression(LambdaExpression expression)
        {
            _indexExpressions.Add(expression);
        }

        protected void AddSharedExpression(LambdaExpression expression)
        {
            _sharedExpressions.Add(expression);
        }
    }

    public abstract class ViewDefinition<TView> : ViewDefinition
    {
        public void Index(Expression<Func<TView, object>> indexedField)
        {
            AddIndexExpression(indexedField);
        }

        public void Share(Expression<Func<TView, object>> sharedField)
        {
            AddSharedExpression(sharedField);
        }
    }
}