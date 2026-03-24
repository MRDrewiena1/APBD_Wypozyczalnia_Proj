using APBD_Wypozyczalnia_Proj.Models;

namespace APBD_Wypozyczalnia_Proj.Services;



public class EquipmentService
{
    private List<Equipment> _equipmentList = new();

    public void AddEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }

    public void RemoveEquipment(long id)
    {
        var eq = GetById(id);
        if (eq != null)
            _equipmentList.Remove(eq);
    }

    public Equipment? GetById(long id)
    {
        return _equipmentList.FirstOrDefault(e => e.Id == id);
    }

    public List<Equipment> GetAll()
    {
        return _equipmentList;
    }

    public List<Equipment> GetAvailable()
    {
        return _equipmentList.Where(e => e.Avalible).ToList();
    }

    public bool IsAvailable(long id)
    {
        var eq = GetById(id);
        return eq != null && eq.Avalible;
    }

    public List<Equipment> Search(string phrase)
    {
        return _equipmentList
            .Where(e =>
                e.Brand.Contains(phrase, StringComparison.OrdinalIgnoreCase) ||
                e.Model.Contains(phrase, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}