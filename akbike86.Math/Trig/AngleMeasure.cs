using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math.Trig
{
    /// <summary>
    /// Defines the unit measure of an angle.
    /// <list type="bullet">
    /// <item><seealso cref="radian"/> (<see cref="rad">rad</see>)<br/>
    /// <list type="bullet">
    ///   <item><seealso cref="milliradian"/> (<see cref="mrad">mrad</see>)</item>
    ///   <item><seealso cref="pi"/></item>
    /// </list></item>
    /// <item><seealso cref="degree"/> (<see cref="deg">deg</see>)
    /// <list type="bullet">
    ///   <item><seealso cref="arcminute"/> (<see cref="arcmin">arcmin</see>/<see cref="minute">minute</see>/<see cref="min">min</see>)</item>
    ///   <item><seealso cref="arcsecond"/> (<see cref="arcsec">arcsec</see>/<see cref="second">second</see>/<see cref="sec">sec</see>)</item>
    /// </list></item>
    /// <item><seealso cref="gradian"/> (<see cref="gon">gon</see>/<see cref="grad">grad</see>)
    /// <list type="bullet">
    ///   <item><seealso cref="centminute"/> (<see cref="centmin">centmin</see>/<see cref="cgon">cgon</see>)</item>
    ///   <item><seealso cref="centsecond"/> (<see cref="centsec">centsec</see>/<see cref="ccgon">ccgon</see>)</item>
    ///   <item></item>
    /// </list></item>
    /// <item><seealso cref="turn"/></item>
    /// <item><seealso cref="sextant"/></item>
    /// </list>
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1069:Enums values should not be duplicated", Justification = "<Pending>")]
    public enum AngleMeasure : byte
    {
        /// <summary>
        /// A unit measure of a full revolution or circle, where the angle is measured as a decimal fraction of 1 (0.0 to 1.0).
        /// </summary>
        turn = 0b11111111,
        /// <summary>
        /// Short name/symbol of <see cref="radian">radian</see>. <inheritdoc cref="radian"/>
        /// </summary>
        rad = radian,
        /// <summary>
        /// Standard (SI) unit of measure of an angle in terms of the ratio of the radius to the subtended angle, with a full <see cref="turn">turn</see> equal to 2π.
        /// </summary>
        radian = 0b00000000,
        /// <summary>
        /// Short name/symbol for <see cref="milliradian">milliradian</see>: <inheritdoc cref="milliradian"/>
        /// </summary>
        mrad = milliradian,
        /// <summary>
        /// One thousandth of a <see cref="radian">radian</see>.<br/>
        /// See <i><u><seealso cref="radian"/></u></i>: <inheritdoc cref="radian"/>
        /// </summary>
        milliradian = 0b00001000,
        /// <summary>
        /// The measure of an angle in terms of π(pi) in radians with a decimal between 0 and 2.
        /// </summary>
        pi = 0b00010000,
        /// <summary>
        /// Short name/symbol of <see cref="degree">degree</see>. <inheritdoc cref="degree"/>
        /// </summary>
        deg = degree,
        /// <summary>
        /// Unit of measure of an angle defined as one three-hundred-sixtieth (1/360) of a full <see cref="turn">turn</see>. Commonly notated as °.
        /// </summary>
        degree = 0b00000001,
        /// <summary>
        /// One arc minute is equal to one sixtieth (1/60) of a <see cref="degree">degree</see>.<br/>
        /// See <i><u><seealso cref="degree"/></u></i>: <inheritdoc cref="degree"/>
        /// </summary>
        arcminute = 0b00001001,
        /// <summary>
        /// Short name/symbol of <see cref="arcminute">arcminute</see>. <inheritdoc cref="arcminute"/>
        /// </summary>
        arcmin = arcminute,
        /// <inheritdoc cref="arcmin" />
        min = arcminute,
        /// <inheritdoc cref="arcmin" />
        minute = arcminute,
        /// <summary>
        /// One arc second is equal to one sixtieth (1/60) of an <see cref="arcminute">arc minute</see>.<br/>
        /// See <i><u><seealso cref="arcminute"/></u></i>: <inheritdoc cref="arcminute"/>
        /// </summary>
        arcsecond = 0b00010001,
        /// <summary>
        /// Short name/symbol of <see cref="arcsecond">arcsecond</see>. <inheritdoc cref="arcsecond"/>
        /// </summary>
        arcsec = arcsecond,
        /// <inheritdoc cref="arcsec" />
        sec = arcsecond,
        /// <inheritdoc cref="arcsec" />
        second = arcsecond,
        /// <summary>
        /// One thousandth of an <see cref="arcsecond">arc second</see>.<br/>
        /// See <i><u><seealso cref="arcsecond"/></u></i>: <inheritdoc cref="arcsecond"/>
        /// </summary>
        milliarcsecond = 0b00011001,
        /// <summary>
        /// Short name/symbol of <see cref="milliarcsecond">milliarcsecond</see>. <inheritdoc cref="milliarcsecond"/>
        /// </summary>
        mas = milliarcsecond,
        /// <summary>
        /// Short name/symbol of <see cref="gradian">gradian</see>. <inheritdoc cref="gradian"/>
        /// </summary>
        grad = 0b00000010,
        /// <summary>
        /// Standard symbol of <see cref="gradian">gradian</see>. <inheritdoc cref="gradian"/>
        /// </summary>
        gon = grad,
        /// <summary>
        /// Unit of measure of an angle defined as one hundreth (1/100) of a right angle (90°) or quarter (¼) turn. Equal to 1/400th of a full <see cref="turn">turn</see>.
        /// </summary>
        gradian = grad,
        /// <summary>
        /// One centesimal arc-minute is equal to one hundreth (1/100) of a <see cref="gradian">gradian</see>. Equal to 1/400,000th of a full <see cref="turn">turn</see>.<br/>
        /// See <i><u><seealso cref="gradian"/></u></i>: <inheritdoc cref="gradian"/>
        /// </summary>
        centminute = 0b00001010,
        /// <summary>
        /// Short name/symbol for centesimal minute. <inheritdoc cref="centminute"/>
        /// </summary>
        centmin = centminute,
        /// <summary>
        /// Short name/symbol for centesimal minute. <inheritdoc cref="centminute"/>
        /// </summary>
        cgon = centminute,
        /// <summary>
        /// One centesimal arc-second is equal to one hundreth (1/100) of a <see cref="centminute">centesimal minute</see>.<br/>
        /// See <i><u><seealso cref="centminute"/></u></i>: <inheritdoc cref="centminute"/>
        /// </summary>
        centsecond = 0b00010010,
        /// <summary>
        /// Short name/symbol for <see cref="centsecond">centesimal second</see>. <inheritdoc cref="centsecond"/>
        /// </summary>
        centsec = centsecond,
        /// <summary>
        /// Short name/symbol for <see cref="centsecond">centesimal second</see>. <inheritdoc cref="centsecond"/>
        /// </summary>
        ccgon = centsecond,
        /// <summary>
        /// Unit of measure of an angle defined as one sixth (1/6) of a <see cref="turn">turn</see>, so 1 sextant = 60°.
        /// </summary>
        sextant = 0b00000100
    }
}
