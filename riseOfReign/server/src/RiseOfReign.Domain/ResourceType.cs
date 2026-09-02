namespace RiseOfReign.Domain;

public enum ResourceType
{
    Treasury,
    Food,
    Coal,
    CrudeOil,
    Fuel,
    NaturalGas,
    IronOre,
    Steel,
    NonFerrousMetals,
    Chemicals,
    IndustrialGoods,
    ConsumerGoods,
    MedicalSupplies,
    MilitaryMaterial,
    StrategicMaterials
}

public sealed record ResourceStock(
    ResourceType Type,
    decimal Amount,
    decimal ReserveTarget,
    decimal StorageCapacity);
