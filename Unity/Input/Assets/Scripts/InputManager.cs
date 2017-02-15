using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetKey
{
    Forward, 
    Backward,
    Left,
    Right,
    Up,
    Down,
    Action,
    None,
}

public enum KeyboardKey
{

    //
    // Summary:
    //     ///
    //     Not assigned (never returned as the result of a keystroke).
    //     ///
    None = 0,
    //
    // Summary:
    //     ///
    //     The backspace key.
    //     ///
    Backspace = 8,
    //
    // Summary:
    //     ///
    //     The tab key.
    //     ///
    Tab = 9,
    //
    // Summary:
    //     ///
    //     The Clear key.
    //     ///
    Clear = 12,
    //
    // Summary:
    //     ///
    //     Return key.
    //     ///
    Return = 13,
    //
    // Summary:
    //     ///
    //     Pause on PC machines.
    //     ///
    Pause = 19,
    //
    // Summary:
    //     ///
    //     Space key.
    //     ///
    Space = 32,
    //
    // Summary:
    //     ///
    //     Exclamation mark key '!'.
    //     ///
    Exclaim = 33,
    //
    // Summary:
    //     ///
    //     Double quote key '"'.
    //     ///
    DoubleQuote = 34,
    //
    // Summary:
    //     ///
    //     Hash key '#'.
    //     ///
    Hash = 35,
    //
    // Summary:
    //     ///
    //     Dollar sign key '$'.
    //     ///
    Dollar = 36,
    //
    // Summary:
    //     ///
    //     Ampersand key '&'.
    //     ///
    Ampersand = 38,
    //
    // Summary:
    //     ///
    //     Quote key '.
    //     ///
    Quote = 39,
    //
    // Summary:
    //     ///
    //     Left Parenthesis key '('.
    //     ///
    LeftParen = 40,
    //
    // Summary:
    //     ///
    //     Right Parenthesis key ')'.
    //     ///
    RightParen = 41,
    //
    // Summary:
    //     ///
    //     Asterisk key '*'.
    //     ///
    Asterisk = 42,
    //
    // Summary:
    //     ///
    //     Plus key '+'.
    //     ///
    Plus = 43,
    //
    // Summary:
    //     ///
    //     Comma ',' key.
    //     ///
    Comma = 44,
    //
    // Summary:
    //     ///
    //     Minus '-' key.
    //     ///
    Minus = 45,
    //
    // Summary:
    //     ///
    //     Period '.' key.
    //     ///
    Period = 46,
    //
    // Summary:
    //     ///
    //     Slash '/' key.
    //     ///
    Slash = 47,
    //
    // Summary:
    //     ///
    //     The '0' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha0 = 48,
    //
    // Summary:
    //     ///
    //     The '1' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha1 = 49,
    //
    // Summary:
    //     ///
    //     The '2' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha2 = 50,
    //
    // Summary:
    //     ///
    //     The '3' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha3 = 51,
    //
    // Summary:
    //     ///
    //     The '4' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha4 = 52,
    //
    // Summary:
    //     ///
    //     The '5' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha5 = 53,
    //
    // Summary:
    //     ///
    //     The '6' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha6 = 54,
    //
    // Summary:
    //     ///
    //     The '7' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha7 = 55,
    //
    // Summary:
    //     ///
    //     The '8' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha8 = 56,
    //
    // Summary:
    //     ///
    //     The '9' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha9 = 57,
    //
    // Summary:
    //     ///
    //     Colon ':' key.
    //     ///
    Colon = 58,
    //
    // Summary:
    //     ///
    //     Semicolon ';' key.
    //     ///
    Semicolon = 59,
    //
    // Summary:
    //     ///
    //     Less than '<' key.
    //     ///
    Less = 60,
    //
    // Summary:
    //     ///
    //     Equals '=' key.
    //     ///
    Equals = 61,
    //
    // Summary:
    //     ///
    //     Greater than '>' key.
    //     ///
    Greater = 62,
    //
    // Summary:
    //     ///
    //     Question mark '?' key.
    //     ///
    Question = 63,
    //
    // Summary:
    //     ///
    //     At key '@'.
    //     ///
    At = 64,
    //
    // Summary:
    //     ///
    //     Left square bracket key '['.
    //     ///
    LeftBracket = 91,
    //
    // Summary:
    //     ///
    //     Backslash key '\'.
    //     ///
    Backslash = 92,
    //
    // Summary:
    //     ///
    //     Right square bracket key ']'.
    //     ///
    RightBracket = 93,
    //
    // Summary:
    //     ///
    //     Caret key '^'.
    //     ///
    Caret = 94,
    //
    // Summary:
    //     ///
    //     Underscore '_' key.
    //     ///
    Underscore = 95,
    //
    // Summary:
    //     ///
    //     Back quote key '`'.
    //     ///
    BackQuote = 96,
    //
    // Summary:
    //     ///
    //     'a' key.
    //     ///
    A = 97,
    //
    // Summary:
    //     ///
    //     'b' key.
    //     ///
    B = 98,
    //
    // Summary:
    //     ///
    //     'c' key.
    //     ///
    C = 99,
    //
    // Summary:
    //     ///
    //     'd' key.
    //     ///
    D = 100,
    //
    // Summary:
    //     ///
    //     'e' key.
    //     ///
    E = 101,
    //
    // Summary:
    //     ///
    //     'f' key.
    //     ///
    F = 102,
    //
    // Summary:
    //     ///
    //     'g' key.
    //     ///
    G = 103,
    //
    // Summary:
    //     ///
    //     'h' key.
    //     ///
    H = 104,
    //
    // Summary:
    //     ///
    //     'i' key.
    //     ///
    I = 105,
    //
    // Summary:
    //     ///
    //     'j' key.
    //     ///
    J = 106,
    //
    // Summary:
    //     ///
    //     'k' key.
    //     ///
    K = 107,
    //
    // Summary:
    //     ///
    //     'l' key.
    //     ///
    L = 108,
    //
    // Summary:
    //     ///
    //     'm' key.
    //     ///
    M = 109,
    //
    // Summary:
    //     ///
    //     'n' key.
    //     ///
    N = 110,
    //
    // Summary:
    //     ///
    //     'o' key.
    //     ///
    O = 111,
    //
    // Summary:
    //     ///
    //     'p' key.
    //     ///
    P = 112,
    //
    // Summary:
    //     ///
    //     'q' key.
    //     ///
    Q = 113,
    //
    // Summary:
    //     ///
    //     'r' key.
    //     ///
    R = 114,
    //
    // Summary:
    //     ///
    //     's' key.
    //     ///
    S = 115,
    //
    // Summary:
    //     ///
    //     't' key.
    //     ///
    T = 116,
    //
    // Summary:
    //     ///
    //     'u' key.
    //     ///
    U = 117,
    //
    // Summary:
    //     ///
    //     'v' key.
    //     ///
    V = 118,
    //
    // Summary:
    //     ///
    //     'w' key.
    //     ///
    W = 119,
    //
    // Summary:
    //     ///
    //     'x' key.
    //     ///
    X = 120,
    //
    // Summary:
    //     ///
    //     'y' key.
    //     ///
    Y = 121,
    //
    // Summary:
    //     ///
    //     'z' key.
    //     ///
    Z = 122,
    //
    // Summary:
    //     ///
    //     The forward delete key.
    //     ///
    Delete = 127,
    //
    // Summary:
    //     ///
    //     Numeric keypad 0.
    //     ///
    Keypad0 = 256,
    //
    // Summary:
    //     ///
    //     Numeric keypad 1.
    //     ///
    Keypad1 = 257,
    //
    // Summary:
    //     ///
    //     Numeric keypad 2.
    //     ///
    Keypad2 = 258,
    //
    // Summary:
    //     ///
    //     Numeric keypad 3.
    //     ///
    Keypad3 = 259,
    //
    // Summary:
    //     ///
    //     Numeric keypad 4.
    //     ///
    Keypad4 = 260,
    //
    // Summary:
    //     ///
    //     Numeric keypad 5.
    //     ///
    Keypad5 = 261,
    //
    // Summary:
    //     ///
    //     Numeric keypad 6.
    //     ///
    Keypad6 = 262,
    //
    // Summary:
    //     ///
    //     Numeric keypad 7.
    //     ///
    Keypad7 = 263,
    //
    // Summary:
    //     ///
    //     Numeric keypad 8.
    //     ///
    Keypad8 = 264,
    //
    // Summary:
    //     ///
    //     Numeric keypad 9.
    //     ///
    Keypad9 = 265,
    //
    // Summary:
    //     ///
    //     Numeric keypad '.'.
    //     ///
    KeypadPeriod = 266,
    //
    // Summary:
    //     ///
    //     Numeric keypad '/'.
    //     ///
    KeypadDivide = 267,
    //
    // Summary:
    //     ///
    //     Numeric keypad '*'.
    //     ///
    KeypadMultiply = 268,
    //
    // Summary:
    //     ///
    //     Numeric keypad '-'.
    //     ///
    KeypadMinus = 269,
    //
    // Summary:
    //     ///
    //     Numeric keypad '+'.
    //     ///
    KeypadPlus = 270,
    //
    // Summary:
    //     ///
    //     Numeric keypad enter.
    //     ///
    KeypadEnter = 271,
    //
    // Summary:
    //     ///
    //     Numeric keypad '='.
    //     ///
    KeypadEquals = 272,
    //
    // Summary:
    //     ///
    //     Up arrow key.
    //     ///
    UpArrow = 273,
    //
    // Summary:
    //     ///
    //     Down arrow key.
    //     ///
    DownArrow = 274,
    //
    // Summary:
    //     ///
    //     Right arrow key.
    //     ///
    RightArrow = 275,
    //
    // Summary:
    //     ///
    //     Left arrow key.
    //     ///
    LeftArrow = 276,
    //
    // Summary:
    //     ///
    //     Insert key key.
    //     ///
    Insert = 277,
    //
    // Summary:
    //     ///
    //     Home key.
    //     ///
    Home = 278,
    //
    // Summary:
    //     ///
    //     End key.
    //     ///
    End = 279,
    //
    // Summary:
    //     ///
    //     Page up.
    //     ///
    PageUp = 280,
    //
    // Summary:
    //     ///
    //     Page down.
    //     ///
    PageDown = 281,
    //
    // Summary:
    //     ///
    //     Right shift key.
    //     ///
    RightShift = 303,
    //
    // Summary:
    //     ///
    //     Left shift key.
    //     ///
    LeftShift = 304,
    //
    // Summary:
    //     ///
    //     Right Control key.
    //     ///
    RightControl = 305,
    //
    // Summary:
    //     ///
    //     Left Control key.
    //     ///
    LeftControl = 306,
    //
    // Summary:
    //     ///
    //     Right Alt key.
    //     ///
    RightAlt = 307,
    //
    // Summary:
    //     ///
    //     Left Alt key.
    //     ///
    LeftAlt = 308,
}

public class InputManager : MonoBehaviour
{
    

}
