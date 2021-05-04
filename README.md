# ResourceDesigner

This is a graphic editor primarily intended to be used with the GuSprites library for ZX Basic.
It can also be used to generate graphics for other systems used in ZX Basic, as custom UDG's or other type of graphic library that uses sprites defined as byte arrays.

![UI screenshot](https://github.com/gusmanb/ResourceDesigner/blob/master/Screenshots/MainInterface.jpg)

It includes some nifty features like:

* Precompute shifted sprites. Useful for programs that use static sprite sets, this will reduce the memory footprint of the GuSprites library.
* Plugin system.  The designer exposes a plugin system that allows anyone to extend the editor easily.
  
This is the first public release, expect bugs ;)
