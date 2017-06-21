//Given a number, find and return the index location in which it would be inserted into, assuming array is sorted lowest to highest value

function getIndexToIns(arr, num) {
  
  arr.sort(function(a,b){   //sort array from smallest to largest
    return a-b;
  });
  
  var position = 0;
  
  for (i=0; i<arr.length; i++){   //increase position until correct index location is found
    
    if(num > arr[i]){
      position += 1;
    }
    else{
      break;
    }
  }
  
  console.log(arr);
  return position;
}
