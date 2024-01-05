#include <stdio.h>
int main()
{
    int n;
    scanf("%d", &n);
    int ar[n];

    for(int i = 0; i< n; i++)
    {
        scanf("%d", &ar[i]);
    }
    
    int s;
    scanf("%d", &s);
   int ans = -1;

   for(int i = 0; i< n; i++)
    {
        if(s == ar[i])
        {
            ans = i;
            break;
        }
    }

   printf("%d", ans);
   
    return 0;
}