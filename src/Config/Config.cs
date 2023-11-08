using System.Collections.Generic;

namespace MorePiles;

public class Config
{
    public Dictionary<string, Pile> Piles = new()
    {
        { "mostCubicBlocks", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 4, TransferQuantity = 1, StackingCapacity = 64 } },
        { "arrow", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "bamboostakes", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 32 } },
        { "beeswax", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 32 } },
        { "bone", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "chutesection", new() { Enabled = true, UpSolid = true, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "cloth", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 48 } },
        { "flaxfibers", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 128 } },
        { "flaxtwine", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 32 } },
        { "metalchain", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 4, TransferQuantity = 1, StackingCapacity = 8 } },
        { "metallamellae", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 4, TransferQuantity = 1, StackingCapacity = 8 } },
        { "metalscale", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 4, TransferQuantity = 1, StackingCapacity = 8 } },
        { "sail", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 2, TransferQuantity = 1, StackingCapacity = 8 } },
        { "stick", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "angledgears", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 4, TransferQuantity = 1, StackingCapacity = 8 } },
        { "axle", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 4, TransferQuantity = 1, StackingCapacity = 16 } },
        { "ironfence", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "torchholder", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 2, TransferQuantity = 1, StackingCapacity = 8 } },
        { "drystonefence", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "henbox", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "ladder", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "sign", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "toolrack", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "trapdoor", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "fence", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "fencegate", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 64 } },
        { "stone", new() { Enabled = true, UpSolid = true, BulkTransferQuantity = 8, TransferQuantity = 1, StackingCapacity = 72 } },
        { "rope", new() { Enabled = true, UpSolid = false, BulkTransferQuantity = 4, TransferQuantity = 1, StackingCapacity = 32 } },
    };

    public Config() { }

    public Config(Config previousConfig)
    {
        Piles = previousConfig.Piles;
    }
}