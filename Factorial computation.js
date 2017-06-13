//with for loop:
function factorialize(num) {
  var count = 1;
  
  for (i=1; i<=num; i++){
    count *= i;
  }
  return count;
}





//with while loop:
function factorialize(num) {
  var i=1;
  var count=1;
  while (i<=num){
    count *= i;
    i++;
  }
  return count;
}
