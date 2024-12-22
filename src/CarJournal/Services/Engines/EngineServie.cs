
using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Engines;

namespace CarJournal.Services.Engines;

public class EngineService : IEngineService
{
    private readonly IEngineRepository _engineRepository;

    public EngineService(IEngineRepository engineRepository)
    {
        _engineRepository = engineRepository;
    }

    public async Task Add(string model, float size)
    {
        var engine = new Engine(0, model, size);

        _engineRepository.Add(engine);
        await _engineRepository.Save();
    }

    public async Task<List<Engine>> GetAllAsync()
    {
        return await _engineRepository.GetAllAsync();
    }

    public async Task Remove(int id)
    {
        if(_engineRepository.GetById(id) is not Engine engine)
        {
            throw new Exception("Engine with given id is not exists");
        }

        _engineRepository.Remove(engine);
        await _engineRepository.Save();
    }

    public async Task Update(int id, string model, float size)
    {
        var engineToEdit = _engineRepository.GetById(id);
        if(engineToEdit is not null)
        {
            engineToEdit.Update(model, size);
            _engineRepository.Update(engineToEdit);
        }
    }
}
