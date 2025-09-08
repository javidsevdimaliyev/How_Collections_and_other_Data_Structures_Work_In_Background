using AVL_Tree;

AVLNodeOperations nop = new();
//nop.ImportData(new int[] { 12, 6, 30, 5, 4 }); //LL Imbalance Simple version
nop.ImportData(new int[] { 14, 7, 25, 6, 8, 3 }); //LL Imbalance Complex version

nop.ImportData(new int[] { 15, 17, 12, 21, 25 }); //RR Imbalance Simple version
nop.ImportData(new int[] { 15, 17, 12, 21, 16, 25 }); //RR Imbalance Complex version

nop.ImportData(new int[] { 10, 4, 20, 3, 7, 5 }); //LR Imbalance Complex version
nop.ImportData(new int[] { 10, 4, 20, 15, 30, 17 }); //RL Imbalance Complex version

nop.Find(17);
//nop.Remove(13);

nop.Traverse();