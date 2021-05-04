# ResourceDesigner

This is a graphic editor primarily intended to be used with the ![GuSprites library](https://github.com/gusmanb/GuSprites) for ![ZX Basic](https://zxbasic.readthedocs.io/en/docs/).
It can also be used to generate graphics for other systems used in ZX Basic, as custom UDG's or other type of graphic library that uses sprites defined as byte arrays.

![UI screenshot](https://github.com/gusmanb/ResourceDesigner/blob/master/Screenshots/MainInterface.jpg)

It includes some nifty features like:

* Precompute shifted sprites. Useful for programs that use static sprite sets, this will reduce the memory footprint of the GuSprites library.
* Plugin system.  The designer exposes a plugin system that allows anyone to extend the editor easily.
* Image Import. Convert images to pixel data (without color), based on pixel luminancy.
* Generate random objects. Who knows what can be generated... xD

This is the first public release, expect bugs ;)
Documentation will be implemented in some weeks, meanwhile if you need any info feel free to contact me.

Happy coding!
