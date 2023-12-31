using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class PoolManager : Manager
    {
        #region Fields
        [Header("Module Fields")]
        [SerializeField] private List<ObjectPool> pools;
        #endregion

        #region Core
        public override void Initialize()
        {
            for (int i = 0; i < pools.Count; i++)
            {
                pools[i].Initilaze();
            }
        }
        #endregion

        #region GetObjVector3
        public PoolObject GetObj(string objName, Vector3 pos, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, false, Quaternion.identity, false, Vector3.one);
            }
            else
            {
                return GetObj(objName, pos, false, Quaternion.identity, false, Vector3.one, true, setParent);
            }
        }
        public PoolObject GetObj(string objName, Vector3 pos, Quaternion rot, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, true, rot, false, Vector3.one);
            }
            else
            {
                return GetObj(objName, pos, true, rot, false, Vector3.one, true, setParent);
            }
        }
        public PoolObject GetObj(string objName, Vector3 pos, Vector3 scale, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, false, Quaternion.identity, true, scale);
            }
            else
            {
                return GetObj(objName, pos, false, Quaternion.identity, true, scale, true, setParent);
            }
        }
        public PoolObject GetObj(string objName, Vector3 pos, Quaternion rot, Vector3 scale, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, true, rot, true, scale);
            }
            else
            {
                return GetObj(objName, pos, true, rot, true, scale, true, setParent);
            }
        }
        #endregion

        #region GetObjGameObject
        public PoolObject GetObj(string objName, Transform targetObj, bool setParent = false)
        {
            return GetObj(objName, targetObj.position, false, Quaternion.identity, false, Vector3.one,
                setParent, targetObj.gameObject);
        }
        public PoolObject GetObj(string objName, Transform targetObj, bool setRot, bool setScale, bool setParent = false)
        {
            return GetObj(objName, targetObj.position, setRot, targetObj.rotation, setScale, targetObj.localScale,
                setParent, targetObj.gameObject);
        }

        #endregion

        #region Clears
        public void ClearPool(string objName)
        {
            for (int i = 0; i < pools.Count; i++)
            {
                if (pools[i].PoolName == objName)
                {
                    pools[i].Reload();
                }
            }
        }
        public void ClearPool()
        {
            for (int i = 0; i < pools.Count; i++)
            {
                pools[i].Reload();
            }
        }
        #endregion

        #region GetObj
        private PoolObject GetObj(string objName, Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale,
           bool setParent = false, GameObject obj = null)
        {
            for (int i = 0; i < pools.Count; i++)
            {
                if (string.Compare(pools[i].PoolName, objName) == 0)
                {
                    return pools[i].GetObj(pos, useRotation, rot, useScale, scale, setParent, obj);
                }
            }
            Debug.LogError(objName + " Cant Found");
            return null;
        }
        #endregion
    }
}
