#include <stdio.h>
void odd_even(void)
{
    int n;

    scanf("%d",&n);

    int input[n];

    for(int i=0; i<n; i++)
    {
        scanf("%d",&input[i]);
    }

    int odd = 0;
    int even = 0;
    for(int i = 0; i<size; i++)
    {
        if(ar[i]%2==0)
        {
            even++;
        }else{
            odd++;
        }
    }

    printf("%d %d", even, odd);
}
int main()
{
    
    odd_even(input,n);

    return 0;
}

