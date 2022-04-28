#pragma once

#include <type_traits>
/*
*	����ģʽ��
*		���캯��
*	    �������졢��ֵ���������ƶ����졢�ƶ���ֵ��������Ӧ��delete
*		
*/

namespace zeus {
	//template<typename T>
	//class singleton
	//{
	//public:
	//	virtual ~singleton() noexcept = default;
	//	singleton(const singleton&) = delete;//����Ϊʲôû��T
	//	singleton& operator =(const singleton&) = delete;

	//	T instance() noexcept(std::is_nothrow_constructible<T>::value) {
	//		static T instance;
	//		return instance;
	//	}
	//private:
	//	singleton() = default;

	//};
	template<typename T>
	class singleton
	{
	protected:
		singleton() = default;
	public:
		virtual ~singleton() noexcept = default;
		singleton(const singleton&) = delete;
		singleton& operator =(const singleton&) = delete;
		singleton(singleton&&) = delete;
		singleton& operator =(singleton&&) = delete;
		static T& instance()
		{	
			static T instance;//magic static ��֤���̰߳�ȫ��û��data-race
			return instance;
		}
	};
}