namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IDropStatementBuilder
    {
        IDrop DropTable(string tableName);
    }
}