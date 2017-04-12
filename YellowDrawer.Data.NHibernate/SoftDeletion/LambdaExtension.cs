using System.Collections.Generic;
using System.Linq.Expressions;

namespace YellowDrawer.Data.NH.SoftDeletion
{
    public static class LambdaExtension
    {
        public static string GetPropertyName(this LambdaExpression property)
        {
            var currentMember = property.Body.TryGetMemberExpression();
            var propertyNameChain = new List<string>();
            while (currentMember != null)
            {
                propertyNameChain.Add(currentMember.Member.Name);
                currentMember = currentMember.Expression.TryGetMemberExpression();
            }
            propertyNameChain.Reverse();
            return string.Join(".", propertyNameChain.ToArray());
        }

        public static MemberExpression TryGetMemberExpression(this Expression expression)
        {
            MemberExpression memberExpression = null;
            switch (expression.NodeType)
            {
                case ExpressionType.Convert:
                    {
                        var body = (UnaryExpression)expression;
                        memberExpression = body.Operand as MemberExpression;
                    }
                    break;
                case ExpressionType.MemberAccess:
                    memberExpression = expression as MemberExpression;
                    break;
            }
            return memberExpression;
        }
    }
}
