using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    Ray m_Ray;
    RaycastHit m_RayCastHit;
    ArrowController m_CurrentObject;
    Vector3 m_LastMousePos;
    float m_DeltaTime;
    bool m_AnimateScale;
    Vector3 m_StartScale;
    float m_ScaleFactor;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_LastMousePos = Input.mousePosition;
            m_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity))
            {
                ArrowController obj = m_RayCastHit.collider.gameObject.GetComponent<ArrowController>();
                if (obj)
                {
                    m_CurrentObject = obj;
                    m_StartScale = obj.transform.localScale;

                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaPosition = Vector3.zero;
            deltaPosition.x = Input.mousePosition.x - m_LastMousePos.x;
            if (deltaPosition.magnitude > 1f)
            {
                if (m_CurrentObject && !m_AnimateScale)
                {
                    m_ScaleFactor = deltaPosition.magnitude;
                    m_AnimateScale = true;
                    m_DeltaTime = 0f;
                }
            }
            m_LastMousePos.x = Input.mousePosition.x;
        }

        if (m_AnimateScale && m_DeltaTime < 1f)
        {
            m_DeltaTime += Time.deltaTime;
            if (m_CurrentObject)
            {
                m_CurrentObject.transform.localScale = Vector3.Lerp(m_CurrentObject.transform.localScale, m_StartScale * m_ScaleFactor, m_DeltaTime);
            }
        }
        else
        {
            m_AnimateScale = false;
            m_DeltaTime = 0f;
        }
    }
}
