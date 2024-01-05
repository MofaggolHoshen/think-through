#include <stdio.h>
int main()
{
    int N;
    scanf("%d", &N);

    long long int sum = 0;
    int a[N];

    for(int i = 0; i < N; i++)
    {
        scanf("%d", &a[i]);
    }

     for(int i = 0; i < N; i++)
     {
        sum = sum + a[i];
     }

    if(sum < 0)
    {
        sum *= -1;
    }

    printf("%lld", sum);

    return 0;
}