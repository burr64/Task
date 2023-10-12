namespace Task.BLL.Interfaces;

public interface IEntityService<TDto>
{
    IEnumerable<TDto> GetAll();
    TDto GetById(int id);
    void Create(TDto dto);
    void Update(TDto dto);
    void Delete(int id);
}