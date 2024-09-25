namespace BlazorMazeGenerator
{


    public class MinHeap
    {
        private const int _DefaultCap = 10;
        private List<int> _heap;
        private int _size;
        private int _capacity;

        public MinHeap() {
            _heap = new List<int>();
            _size = 0;
            _capacity = _DefaultCap;
            return arr_heap;
        }
        
    }


    int arrheap_parent(ArrayHeap* arr_heap, int index)
    {
        if (index > 0 && index < arr_heap->size)
        {
            return (index - 1) / 2;
        }
        // printf("No parent found");
        return -1;
    }

    int arrheap_left_child(ArrayHeap* arr_heap, int index)
    {
        if (index * 2 + 1 < arr_heap->size)
        {
            return index * 2 + 1;
        }
        else
        {
            // printf("No left child found");
            return -1;
        }
    }

    int arrheap_right_child(ArrayHeap* arr_heap, int index)
    {
        if (index * 2 + 2 < arr_heap->size)
        {
            return index * 2 + 2;
        }
        else
        {
            // printf("No right child found");
            return -1;
        }


    }

    // void arrheap_perc_down(ArrayHeap* arr_heap, int root){
    //     int left_child = arrheap_left_child(arr_heap,root);
    //     if(left_child == -1){
    //         return;
    //     }

    //     while(left_child < arr_heap->size){
    //         if(left_child < arr_heap->size - 1 && arr_heap->heap[left_child] < arr_heap->heap[left_child+1]){
    //             left_child++;
    //         }
    //         if(arr_heap->heap[root] < arr_heap->heap[left_child]){
    //             int tmp = arr_heap->heap[root];
    //             arr_heap->heap[root] = arr_heap->heap[left_child];
    //             arr_heap->heap[left_child] = tmp;
    //             root = left_child;
    //             left_child = 2 * left_child;
    //         }
    //         else{
    //             break;
    //         }
    //         left_child++;
    //     }


    // }

    // void arrheap_perc_up(ArrayHeap* arr_heap, int index){
    //     int num = arr_heap->heap[index];
    //     int size = arr_heap->size + 1;
    //     index = size + 1;

    //     while(index > 0 && num > arr_heap->heap[index/2]){
    //         arr_heap->heap[index] = arr_heap->heap[index/2];
    //         index = index / 2;
    //     }
    //     arr_heap->heap[index] = num;

    // }

    // void arrheap_increase_key(ArrayHeap* arr_heap, int index, int key){
    //     if(key < arr_heap->heap[index]){
    //         printf("New key must be larger than current key");
    //         return;
    //     }
    //     arr_heap->heap[index] = key;
    //     int parent = arrheap_parent(arr_heap,index);
    //     while(index > 0 && arr_heap->heap[parent]){
    //         swap(arr_heap->heap,index,parent);
    //         index = arrheap_parent(arr_heap,index);
    //     }
    // }

    void arrheap_heapify(ArrayHeap* arr_heap, int root)
    {
        int left = arrheap_left_child(arr_heap, root);
        int right = arrheap_right_child(arr_heap, root);
        int min = root;
        if (left > 0 && left < arr_heap->size && arr_heap->heap[left] < arr_heap->heap[root])
        {
            min = left;
        }
        if (right > 0 && right < arr_heap->size && arr_heap->heap[right] < arr_heap->heap[min])
        {
            min = right;
        }
        if (min != root)
        {
            swap(arr_heap->heap, root, min);
            arrheap_heapify(arr_heap, min);
        }

        // int i = root;
        // int j = (i-1)/2;
        // if(arr_heap->heap[i] < arr_heap->heap[j]){

        //     while(arr_heap->heap[i] < arr_heap->heap[j]){
        //         swap(arr_heap->heap,i,j);
        //         i = j;
        //         j = (j-1)/2;
        //     } 
        //     return;
        // }
        // j = 2*i+1;
        // int k = 2*i+2;
        // if(arr_heap->heap[i] > arr_heap->heap[k] && arr_heap->heap[i] > arr_heap->heap[j]){
        //     while(arr_heap->heap[i] > arr_heap->heap[k] && arr_heap->heap[i] > arr_heap->heap[j]){
        //         if(arr_heap->heap[j] > arr_heap->heap[k]){
        //             swap(arr_heap->heap,i,j);
        //             i = j;
        //             j = 2*j+1;
        //             k = 2*j+2;
        //         }
        //         else{
        //             swap(arr_heap->heap,i,k);
        //             i = j;
        //             j = 2*k+1;
        //             k = 2*k+2;
        //         }

        //     }
        //     return;
        // }


        // int left = arrheap_left_child(arr_heap,root);
        // int right = arrheap_right_child(arr_heap,root);
        // int max = -1;
        // if(left < arr_heap->size && arr_heap->heap[left] > arr_heap->heap[root]){
        //     max = left;
        // }
        // else{
        //     max = root;
        // }
        // if(right < arr_heap->size && arr_heap->heap[right] > arr_heap->heap[max]){
        //     max = right;
        // }
        // if(max != root){
        //     swap(arr_heap->heap,root,max);
        //     arrheap_heapify(arr_heap,max);
        // }

        // int i = root;
        // int j = (i-1)/2;
        // if(arr_heap->heap[i] < arr_heap->heap[j]){

        //     while(arr_heap->heap[i] < arr_heap->heap[j]){
        //         swap(arr_heap->heap,i,j);
        //         i = j;
        //         j = (j-1)/2;
        //     } 
        //     return;
        // }
        // j = 2*i+1;
        // int k = 2*i+2;
        // if(arr_heap->heap[i] > arr_heap->heap[k] && arr_heap->heap[i] > arr_heap->heap[j]){
        //     while(arr_heap->heap[i] > arr_heap->heap[k] && arr_heap->heap[i] > arr_heap->heap[j]){
        //         if(arr_heap->heap[j] > arr_heap->heap[k]){
        //             swap(arr_heap->heap,i,j);
        //             i = j;
        //             j = 2*j+1;
        //             k = 2*j+2;
        //         }
        //         else{
        //             swap(arr_heap->heap,i,k);
        //             i = j;
        //             j = 2*k+1;
        //             k = 2*k+2;
        //         }

        //     }
        //     return;
        // }

    }

    bool arrheap_insert(ArrayHeap* arr_heap, int num)
    {
        if (arr_heap == NULL)
        {
            return false;
        }
        if (arr_heap->size == arr_heap->capacity)
        {
            reallocate(arr_heap->heap, 0, arr_heap->size, &(arr_heap->capacity));
        }
        int i = arr_heap->size;
        arr_heap->heap[i] = num;
        arr_heap->size++;

        while (i != 0 && arr_heap->heap[arrheap_parent(arr_heap, i)] > arr_heap->heap[i])
        {
            swap(arr_heap->heap, i, arrheap_parent(arr_heap, i));
            i = arrheap_parent(arr_heap, i);
        }


        // arr_heap->heap[arr_heap->size] = num;
        // arr_heap->size++;
        // arrheap_heapify(arr_heap,arr_heap->size - 1);
        // // arrheap_increase_key(arr_heap,arr_heap->size,num);
        // if(arr_heap->size == arr_heap->capacity){
        //     arr_heap->heap = reallocate(arr_heap->heap,0,arr_heap->size,&(arr_heap->capacity));
        // }
        // return true;
    }

    int arrheap_remove(ArrayHeap* arr_heap, int index)
    {
        if (arr_heap == NULL)
        {
            return index / 0;
        }
        arr_heap->heap[index] = INT_MIN;
        while (index != 0 && arr_heap->heap[arrheap_parent(arr_heap, index)] > arr_heap->heap[index])
        {
            swap(arr_heap->heap, index, arrheap_parent(arr_heap, index));
            index = arrheap_parent(arr_heap, index);
        }
        arrheap_extract_root(arr_heap);
        // swap(arr_heap->heap,index,arr_heap->size-1);
        // arr_heap->heap[index] = 0;
        // arr_heap->size--;
        // arrheap_heapify(arr_heap,index);

    }

    int arrheap_extract_root(ArrayHeap* arr_heap)
    {
        if (arr_heap == NULL)
        {
            return 1 / 0;
        }
        if (arr_heap->size == 1)
        {
            arr_heap->size--;
            return arr_heap->heap[0];
        }
        int root = arr_heap->heap[0];
        arr_heap->heap[0] = arr_heap->heap[arr_heap->size - 1];
        arr_heap->size--;
        arrheap_heapify(arr_heap, 0);
        return root;
    }

    void arrheap_build_heap(ArrayHeap* arr_heap)
    {
        for (int i = floor((arr_heap->size - 1) / 2); i >= 0; i--)
        {
            arrheap_heapify(arr_heap, i);
        }
    }

    void arrheap_heap_sort(ArrayHeap* arr_heap)
    {
        arrheap_build_heap(arr_heap);
        int* sorted = (int*)malloc(sizeof(int) * arr_heap->capacity);
        int size = arr_heap->size;
        for (int i = 0; i < size; i++)
        {
            sorted[i] = arrheap_extract_root(arr_heap);
        }
        free(arr_heap->heap);
        arr_heap->heap = sorted;
        arr_heap->size = size;

        return;
    }

    void arrheap_to_string(ArrayHeap* arr_heap)
    {
        if (arr_heap == NULL)
        {
            return;
        }
        printf("[");
        for (int i = 0; i < arr_heap->size - 1; i++)
        {
            printf("%d, ", arr_heap->heap[i]);
        }
        printf("%d]", arr_heap->heap[arr_heap->size - 1]);
    }







    void swap(int* arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
