using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace YameTools.Extensions
{
    public class ExpressionReplacer : ExpressionVisitor
    {
        readonly IDictionary<Expression, Expression> _replaceMap;

        public ExpressionReplacer(IDictionary<Expression, Expression> replaceMap)
        {
            _replaceMap = replaceMap ?? throw new ArgumentNullException(nameof(replaceMap));
        }

        public override Expression Visit(Expression exp)
        {
            if (exp != null && _replaceMap.TryGetValue(exp, out var replacement))
                return replacement;
            return base.Visit(exp);
        }

        public static Expression Replace(Expression expr, Expression toReplace, Expression toExpr)
        {
            return new ExpressionReplacer(new Dictionary<Expression, Expression> { { toReplace, toExpr } }).Visit(expr);
        }

        public static Expression Replace(Expression expr, IDictionary<Expression, Expression> replaceMap)
        {
            return new ExpressionReplacer(replaceMap).Visit(expr);
        }

        public static Expression GetBody(LambdaExpression lambda, params Expression[] toReplace)
        {
            if (lambda.Parameters.Count != toReplace.Length)
                throw new InvalidOperationException();

            return new ExpressionReplacer(Enumerable.Range(0, lambda.Parameters.Count)
                .ToDictionary(i => (Expression)lambda.Parameters[i], i => toReplace[i])).Visit(lambda.Body);
        }
    }
}
