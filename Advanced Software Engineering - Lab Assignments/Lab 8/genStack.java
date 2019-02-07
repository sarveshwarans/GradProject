/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package genericstack;

import java.util.Arrays;

/**
 *
 * @author Dr Hoffman
 */
public class genStack<E> {
    private  Object[] data;
    private int top;
    public genStack(int size){
        if(size<0)
            throw new IllegalArgumentException("Illegal size:" + size);
        data = new Object[size];
        top = -1;
    }
    public genStack(){
        this(10);
    }
    public void push(E e){
        top++;
        if(top<data.length){
            data[top] = e;
            return;
        }
        
        throw new IndexOutOfBoundsException("push @ " + top);
           
    }
    public E pop() {
        if(top>=0) {
            return (E) data[top--];
        }
        throw new   IndexOutOfBoundsException("pop @ " + top);    
    }
    public boolean isEmpty() {
        return top<0;
    }
    
}
