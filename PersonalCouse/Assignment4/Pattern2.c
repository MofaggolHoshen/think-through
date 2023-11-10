#include <stdio.h>
int main()
{
   int n;
   scanf("%d",&n);
     
   int space = n;

   for(int i = 1; i<= n; i++)
   {
        for(int j = 1; j< space; j++)
            {
                printf(" ");
            }
    for(int k = i; k>=1; k--)
    {
        printf("%d",k);
    }
     printf("\n");

     space = space - 1;
   }

    return 0;
}