﻿using System.Linq.Expressions;
using System.Linq;

namespace MapperExpression.Core.Visitor
{
    internal class ChangParameterExpressionVisitor : ExpressionVisitor
    {
        private Expression[] _parameter;      
        internal ChangParameterExpressionVisitor(params Expression[] parameter)
        {
            _parameter = parameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node != null)
            {
                

                    Expression returnParameter = _parameter.FirstOrDefault(x => x.Type == node.Type);
                    if (returnParameter !=null)
                        return returnParameter;
                    return base.VisitParameter(node); 
            }
            return node;
        }
       
    }
}
