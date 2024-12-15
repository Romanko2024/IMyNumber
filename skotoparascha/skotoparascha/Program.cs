
int[] a = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
int n = 10;
for (int i = 0; i < n; i++)
{
    int k = a[i];
    a[k] = 0;
}
foreach (int element in a)
{
    Console.Write(element + " ");
}

