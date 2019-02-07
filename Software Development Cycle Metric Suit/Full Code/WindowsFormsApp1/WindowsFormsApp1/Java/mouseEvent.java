public class mouseEvent {
public void countRepeatedChars(String someLongString) 
{
Dictionary<char,int> charCount= new Dictionary<char,int>();

for(int i=0;i<someLongString.Length;i++)
{
	if(charCount.Containskey(someLongString[i]))
		charCount[someLongString[i]]++;
	else
		charCount.Addkey(someLongString[i],1);
}
foreach(var c in charCount)
	Console.WriteLine("Char= {0}, Count={1}", c.key, c.value.toString());
}	
}