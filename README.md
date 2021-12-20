# Sorting_Wars
Sorting app for Windows with graphic representation of the process.\
It showcases
### a type of Bubble sort:
``    int n = arr.Length;``\
``    int x = 0;``\
``    for(int i = 0;i<n;i++)``\
``        for(int j=0;j<n;j++)``\
``            if (arr[j]>arr[i]){``\
``                x = lista[j]``\
``                lista[j] = lista[i]``\
``                lista[i] = x``\
``                }``
### Selection Sort
``        int n = arr.Length;``\
``        for (int i = 0; i < n - 1; i++)``\
``        {                             ``\
``            int min_idx = i;``\
``            for (int j = i + 1; j < n; j++)``\
``                if (arr[j] < arr[min_idx])``\
``                    min_idx = j;``\
``                                          ``\
``            int temp = arr[min_idx];``\
``            arr[min_idx] = arr[i];``\
``            arr[i] = temp;``\
``       }``

### Insertion Sort
`int n = arr.Length;`\
`      for (int i = 1; i < n; ++i) {`\
`            int key = arr[i];`\
`            int j = i - 1;`\
`                                  `\
`            while (j >= 0 && arr[j] > key) {`\
`                arr[j + 1] = arr[j];`\
`                j = j - 1;`\
`            }`\
`            arr[j + 1] = key;`\
`        }`

![image](https://user-images.githubusercontent.com/88843916/146702091-5f7b2071-20db-4e47-a499-4dc052e9b183.png)



   



### Created with 

<img align="left" alt="C#" width="38px" src="https://seeklogo.com/images/C/c-sharp-c-logo-02F17714BA-seeklogo.com.png" />
<img align="left" alt="Unity" width="38px" src="https://brandslogos.com/wp-content/uploads/images/large/unity-logo.png" />

