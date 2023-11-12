#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int main()
{
    int test;
    scanf("%d", &test);

    for (int t = 1; t <= test; t++)
    {
        int n;
        scanf("%d", &n);

        int a[n];
        int b[n];
        int c[n];

        for (int i = 0; i < n; i++)
        {
            scanf("%d", &a[i]);
        }

        // Copy
        int index = 0;
        for (int j = n - 1; j >= 0; j--)
        {
            b[index] = a[j];

            index++;
        }

        // Sorting

        for(int s=0; s<n; s++)
        {
            for(int s1=s+1; s1<n; s1++)
            {
                if(b[s] >= b[s1])
                {
                    int temp = b[s];
                    b[s] = b[s1];
                    b[s1] = temp;
                }
            }
        }

        // the absolute difference between array A[i] and B[i].
        for (int k = 0; k < n; k++)
        {
            c[k] = abs(a[k] - b[k]);
        }

        // Print
        for (int k = 0; k < n; k++)
        {
            printf("%d ", c[k]);
        }

        printf("\n");
    }
    return 0;
}