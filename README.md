# engines-lab
 
new Stuff:  
Press E to shoot  
in the Player GameObject, toggle the bool for queue usage or not  
https://user-images.githubusercontent.com/56273460/138890054-d78c33e8-3034-4c0d-a395-3b0029929286.mp4


Old stuff:  
within the assets/scripts/Factory Design Pattern/ folder, there is an IFactory interface script  
in assets/scripts/Command Pattern/ folder, there are two subclasses of the above: CubePlacer and PillPlacer  
in the above folder, InputPlane has an array of IFactories, one is created as CubePlacer, one as PillPlacer  
There is a function to set the index within this array to change which IFactory is used
