function reverseString(str) {
  array = str.split('');   //convert string into array
  array.reverse();         //perform array reverse
  str = array.join('');    //convert array back to string
  
  return str;
}
