using Cairo_book_fair.Models;

public interface IVisitorRepository
{
    public List<Visitors> GetAll();
    public Visitors Update(int id, Visitors visitor);

    public Visitors Add(Visitors visitor);
}