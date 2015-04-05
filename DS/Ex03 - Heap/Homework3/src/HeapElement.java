public class HeapElement { 

	private int key; 
	private Object data; 


	public HeapElement (int key, Object value) { 
		this.key  = key; 
		this.data = value; 
	} 

	public int getKey() {
		return key; 
	} 

	public void setKey (int key) { 
		this.key = key; 
	} 

	public Object getData() { 
		return data; 
	} 

	public void setData (Object data) { 
		this.data = data; 
	} 


} 