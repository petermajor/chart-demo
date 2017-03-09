
var css  = '.stx_candle_down, .stx_line_down { color: #f94949; border-left-color: #f94949; } ';
    css += '.stx_candle_up, .stx_line_up { color: #0a78fc; border-left-color: #0a78fc; } ';
    css += '.stx_candle_shadow, .stx_bar_even { color:#d8d8d8; } ';
    css += '.stx_jump_today { width: 0px; height: 0px; } ';

var styleTag = document.createElement("style");
styleTag.textContent = css;
document.head.appendChild(styleTag);
