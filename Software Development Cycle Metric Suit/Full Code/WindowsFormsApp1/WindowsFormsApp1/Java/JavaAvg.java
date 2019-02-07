public class JavaExample {

    public static void main(String[] args) {
        double[] arr = {19, 12.89, 16.5, 200, 13.7, 45.4, 45.4};
        double total = 0;

        for(int i=0; i<arr.length; i++){
        	total = total + arr[i];
        }
		/*Hello, World*/
        double average = total / arr.length;
        
        System.out.format("The average is: %.3f", average);
    }
}