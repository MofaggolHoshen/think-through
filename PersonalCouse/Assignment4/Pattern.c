#include <stdio.h>
int main()
{
   int n;
   scanf("%d",&n);

   int line = n*2;
   int hash = 1;
   int space = n;

   int space2 = 1;
   int hash2 = line - 3;

   for(int i = 1; i< line; i++)
   {

    if(i <= n)
    {
     for(int j = 1; j<space; j++)
        {
            printf(" ");
        }

        if(i%2 != 0)
        {
            for(int k = 1; k<=hash; k++)
            {
                printf("#");
            }
        }else{
            for(int k = 1; k<=hash; k++)
            {
                printf("-");
            }
        }

        hash +=2;
        space -=1;
    }else{
        for(int j = 1 ; j <=space2; j++)
        {
            printf(" ");
        }

        if(i%2 != 0)
        {
            for(int k = hash2 ; k>=1; k--)
            {
                printf("#");
            }
        }else{
            for(int k = hash2 ; k>=1; k--)
            {
                printf("-");
            }
        }

        hash2 -=2;
        space2 +=1;
    }

    
    printf("\n");

   }
    return 0;
}