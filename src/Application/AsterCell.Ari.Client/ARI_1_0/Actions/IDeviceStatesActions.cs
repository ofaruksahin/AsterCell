﻿using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Actions
{
    public interface IDeviceStatesActions
    {
        /// <summary>
        /// List all ARI controlled device states.. 
        /// </summary>
        List<DeviceState> List();
        /// <summary>
        /// Retrieve the current state of a device.. 
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        DeviceState Get(string deviceName);
        /// <summary>
        /// Change the state of a device controlled by ARI. (Note - implicitly creates the device state).. 
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <param name="deviceState">Device state value</param>
        void Update(string deviceName, string deviceState);
        /// <summary>
        /// Destroy a device-state controlled by ARI.. 
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        void Delete(string deviceName);

        /// <summary>
        /// List all ARI controlled device states.. 
        /// </summary>
        Task<List<DeviceState>> ListAsync();
        /// <summary>
        /// Retrieve the current state of a device.. 
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        Task<DeviceState> GetAsync(string deviceName);
        /// <summary>
        /// Change the state of a device controlled by ARI. (Note - implicitly creates the device state).. 
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <param name="deviceState">Device state value</param>
        Task UpdateAsync(string deviceName, string deviceState);
        /// <summary>
        /// Destroy a device-state controlled by ARI.. 
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        Task DeleteAsync(string deviceName);
    }
}
