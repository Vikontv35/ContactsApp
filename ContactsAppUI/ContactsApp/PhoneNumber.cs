﻿using System;

/// <summary>
/// Класс, хранящий номер телефона контакта
/// </summary>
public class PhoneNumber
{
    /// <summary>
    /// Хранит номер телефона
    /// </summary>
    private long _number;

    /// <summary>
    /// Возвращает и задаёт номер телефона
    /// </summary>
    public long Number
    {
        get { return _number; }
        set
       {
            
            if(value<10000000000 || value > 99999999999)
            {
                throw new ArgumentException("Номер должен состоять из 11 цифр.");
            }
            if(value<70000000000 || value >79999999999)
            {
                throw new ArgumentException("Номер должен начинаться с цифры 7.");
            }
            else { _number = value; }
        }
    }
    /*
    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="number"></param>
    public PhoneNumber(long number)
    {
        Number = number;
    }
    */
    /// <summary>
    /// Конструктор класса
    /// </summary>
    public PhoneNumber() { }
}
