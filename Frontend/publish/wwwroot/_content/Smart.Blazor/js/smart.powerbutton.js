
/* Smart UI v20.0.64 (2024-10-28) 
Copyright (c) 2011-2024 jQWidgets. 
License: https://htmlelements.com/license/ */ //

Smart("smart-power-button",class extends Smart.ToggleButton{static get styleUrls(){return["smart.powerbutton.css"]}template(){return"<div id='container' class='smart-container'>\n                    <div id='powerButtonAnimation' class='smart-animation'></div>\n                    <span id='button' class='smart-input' aria-hidden=\"true\"></span>\n                    <input id='hiddenInput' class='smart-hidden-input' type='hidden'>\n                </div>"}ready(){super.ready(),this._updateHidenInputNameAndValue()}});